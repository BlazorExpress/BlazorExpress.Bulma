if (!window.blazorexpress) {
    window.blazorexpress = {};
}

if (!window.blazorexpress.bulma) {
    window.blazorexpress.bulma = {};
}

window.blazorexpress.bulma = {
    googlemaps: {
        addMarker: (elementId, marker, dotNetHelper) => {
            let mapInstance = window.blazorexpress.bulma.googlemaps.get(elementId);
            if (mapInstance) {
                let map = mapInstance.map;
                let clickable = mapInstance.clickable;
                let _content;

                if (marker.pinElement) {
                    let _glyph;

                    if (marker.pinElement.useIconFonts) {
                        const icon = document.createElement("div");
                        icon.innerHTML = `<i class="${marker.pinElement.glyph}"></i>`;
                        _glyph = icon;
                    } else {
                        _glyph = marker.pinElement.glyph;
                    }

                    const pin = new google.maps.marker.PinElement({
                        background: marker.pinElement.background,
                        borderColor: marker.pinElement.borderColor,
                        glyph: _glyph,
                        glyphColor: marker.pinElement.glyphColor,
                        scale: marker.pinElement.scale,
                    });
                    _content = pin.element;
                }
                else if (marker.content) {
                    _content = document.createElement("div");
                    _content.classList.add("be-bulma-google-marker-content");
                    _content.innerHTML = marker.content;
                }

                const markerEl = new google.maps.marker.AdvancedMarkerElement({
                    map,
                    content: _content,
                    position: marker.position,
                    title: marker.title,
                    gmpClickable: clickable
                });

                window.blazorexpress.bulma.googlemaps.markerEls[elementId].push(markerEl);

                // add a click listener for each marker, and set up the info window.
                if (clickable) {
                    markerEl.addListener("click", ({ domEvent, latLng }) => {
                        const { target } = domEvent;
                        const infoWindow = new google.maps.InfoWindow();
                        infoWindow.close();
                        infoWindow.setContent(markerEl.title);
                        infoWindow.open(markerEl.map, markerEl);
                        dotNetHelper.invokeMethodAsync('OnMarkerClickJS', marker);
                    });
                }
            }
        },
        create: (elementId, map, zoom, center, markers, clickable) => {
            window.blazorexpress.bulma.googlemaps.instances[elementId] = {
                map: map,
                zoom: zoom,
                center: center,
                markers: markers,
                clickable: clickable
            };
        },
        get: (elementId) => {
            return window.blazorexpress.bulma.googlemaps.instances[elementId];
        },
        initialize: (elementId, zoom, center, markers, clickable, dotNetHelper) => {
            window.blazorexpress.bulma.googlemaps.markerEls[elementId] = window.blazorexpress.bulma.googlemaps.markerEls[elementId] ?? [];

            let mapOptions = { center: center, zoom: zoom, mapId: elementId };
            let map = new google.maps.Map(document.getElementById(elementId), mapOptions);

            window.blazorexpress.bulma.googlemaps.create(elementId, map, zoom, center, markers, clickable);

            if (markers) {
                for (const marker of markers) {
                    window.blazorexpress.bulma.googlemaps.addMarker(elementId, marker, dotNetHelper);
                }
            }
        },
        instances: {},
        markerEls: {},
        updateMarkers: (elementId, markers, dotNetHelper) => {
            let markerEls = window.blazorexpress.bulma.googlemaps.markerEls[elementId] ?? [];

            // delete the markers
            if (markerEls.length > 0) {
                for (const markerEl of markerEls) {
                    markerEl.setMap(null);
                }
            }

            if (markers) {
                for (const marker of markers) {
                    window.blazorexpress.bulma.googlemaps.addMarker(elementId, marker, dotNetHelper);
                }
            }
        }
    },
    menu: {
        initialize: (elementId, dotNetHelper) => {
            window.addEventListener("resize", () => {
                dotNetHelper.invokeMethodAsync('WindowResizeJS', window.innerWidth);
            });
        },
        windowSize: () => window.innerWidth
    },
    numberInput: {
        initialize: (elementId, isFloat, allowNegativeNumbers, numberDecimalSeparator) => {
            let numberEl = document.getElementById(elementId);

            numberEl?.addEventListener('keydown', function (event) {
                let invalidChars = ["e", "E", "+"];
                if (!isFloat) {
                    invalidChars.push("."); // restrict '.' for integer types
                    invalidChars.push(numberDecimalSeparator); // restrict ',' for specific culture
                }

                if (!allowNegativeNumbers) {
                    invalidChars.push("-"); // restrict '-'
                }

                if (invalidChars.includes(event.key))
                    event.preventDefault();
            });

            numberEl?.addEventListener('beforeinput', function (event) {
                if (event.inputType === 'insertFromPaste' || event.inputType === 'insertFromDrop') {

                    if (!allowNegativeNumbers) {
                        // restrict 'e', 'E', '+', '-'
                        if (isFloat && /[\e\E\+\-]/gi.test(event.data)) {
                            event.preventDefault();
                        }
                        // restrict 'e', 'E', '.', '+', '-'
                        else if (!isFloat && /[\e\E\.\+\-]/gi.test(event.data)) {
                            event.preventDefault();
                        }
                    }
                    // restrict 'e', 'E', '+'
                    else if (isFloat && /[\e\E\+]/gi.test(event.data)) {
                        event.preventDefault();
                    }
                    // restrict 'e', 'E', '.', '+'
                    else if (!isFloat && /[\e\E\.\+]/gi.test(event.data)) {
                        event.preventDefault();
                    }

                }
            });
        },
        setValue: (elementId, value) => {
            document.getElementById(elementId).value = value;
        }
    },
    splitView: {
        apply: (instance) => {
            if (!instance?.element || !instance?.options) {
                return;
            }

            instance.element.style.setProperty("--be-bulma-split-view-primary-pane-size", `${instance.options.primaryPaneSize}%`);
            instance.element.style.setProperty("--be-bulma-split-view-minimum-pane-size", `${instance.options.minimumPaneSize}%`);
        },
        clamp: (value, minimumPaneSize) => {
            return Math.min(100 - minimumPaneSize, Math.max(minimumPaneSize, value));
        },
        dispose: (elementId) => {
            const instance = window.blazorexpress.bulma.splitView.instances[elementId];
            if (!instance) {
                return;
            }

            window.removeEventListener("pointermove", instance.onPointerMove);
            window.removeEventListener("pointerup", instance.onPointerUp);
            window.removeEventListener("pointercancel", instance.onPointerCancel);

            if (instance.activePointerId !== null && instance.divider?.hasPointerCapture?.(instance.activePointerId)) {
                instance.divider.releasePointerCapture(instance.activePointerId);
            }

            instance.divider?.removeEventListener("pointerdown", instance.onPointerDown);
            instance.element?.classList.remove("be-bulma-split-view-dragging");

            delete window.blazorexpress.bulma.splitView.instances[elementId];
        },
        getPercentage: (instance, event) => {
            const rect = instance.element.getBoundingClientRect();

            if (instance.options.isHorizontal) {
                if (rect.width <= 0) {
                    return instance.options.primaryPaneSize;
                }

                return ((event.clientX - rect.left) / rect.width) * 100;
            }

            if (rect.height <= 0) {
                return instance.options.primaryPaneSize;
            }

            return ((event.clientY - rect.top) / rect.height) * 100;
        },
        initialize: (elementId, options, dotNetHelper) => {
            const element = document.getElementById(elementId);
            const divider = element?.querySelector(".be-bulma-split-view-divider");

            if (!element || !divider) {
                return;
            }

            if (window.blazorexpress.bulma.splitView.instances[elementId]) {
                const instance = window.blazorexpress.bulma.splitView.instances[elementId];
                instance.options = options;
                instance.dotNetHelper = dotNetHelper;
                instance.element = element;
                instance.divider = divider;
                window.blazorexpress.bulma.splitView.apply(instance);
                return;
            }

            const instance = {
                activePointerId: null,
                divider: divider,
                dotNetHelper: dotNetHelper,
                dragging: false,
                element: element,
                onPointerCancel: null,
                onPointerDown: null,
                onPointerMove: null,
                onPointerUp: null,
                options: options
            };

            instance.onPointerDown = (event) => {
                if (instance.options.isDisabled) {
                    return;
                }

                if (event.pointerType === "mouse" && event.button !== 0) {
                    return;
                }

                if (event.isPrimary === false) {
                    return;
                }

                if (event.cancelable) {
                    event.preventDefault();
                }

                instance.dragging = true;
                instance.activePointerId = event.pointerId ?? null;
                instance.element.classList.add("be-bulma-split-view-dragging");

                if (instance.activePointerId !== null && typeof instance.divider.setPointerCapture === "function") {
                    try {
                        instance.divider.setPointerCapture(instance.activePointerId);
                    } catch {
                    }
                }

                if (instance.options.notifyResizeStarted) {
                    instance.dotNetHelper.invokeMethodAsync("OnResizeStartedJS", instance.options.primaryPaneSize, 100 - instance.options.primaryPaneSize);
                }

                window.addEventListener("pointermove", instance.onPointerMove);
                window.addEventListener("pointerup", instance.onPointerUp);
                window.addEventListener("pointercancel", instance.onPointerCancel);
            };

            instance.onPointerMove = (event) => {
                if (!instance.dragging) {
                    return;
                }

                if (instance.activePointerId !== null && event.pointerId !== instance.activePointerId) {
                    return;
                }

                if (event.cancelable) {
                    event.preventDefault();
                }

                const nextPaneSize = window.blazorexpress.bulma.splitView.clamp(
                    window.blazorexpress.bulma.splitView.getPercentage(instance, event),
                    instance.options.minimumPaneSize);

                if (Math.abs(nextPaneSize - instance.options.primaryPaneSize) < 0.01) {
                    return;
                }

                instance.options.primaryPaneSize = nextPaneSize;
                window.blazorexpress.bulma.splitView.apply(instance);

                if (instance.options.notifyResize) {
                    instance.dotNetHelper.invokeMethodAsync("OnResizedJS", nextPaneSize, 100 - nextPaneSize);
                }
            };

            instance.onPointerUp = (event) => {
                if (!instance.dragging) {
                    return;
                }

                if (instance.activePointerId !== null && event?.pointerId !== undefined && event.pointerId !== instance.activePointerId) {
                    return;
                }

                const pointerId = instance.activePointerId;
                instance.dragging = false;
                instance.activePointerId = null;
                instance.element.classList.remove("be-bulma-split-view-dragging");

                window.removeEventListener("pointermove", instance.onPointerMove);
                window.removeEventListener("pointerup", instance.onPointerUp);
                window.removeEventListener("pointercancel", instance.onPointerCancel);

                if (pointerId !== null && instance.divider?.hasPointerCapture?.(pointerId)) {
                    instance.divider.releasePointerCapture(pointerId);
                }

                instance.dotNetHelper.invokeMethodAsync("OnResizeEndedJS", instance.options.primaryPaneSize, 100 - instance.options.primaryPaneSize);
            };

            instance.onPointerCancel = (event) => {
                instance.onPointerUp(event);
            };

            divider.addEventListener("pointerdown", instance.onPointerDown);

            window.blazorexpress.bulma.splitView.instances[elementId] = instance;
            window.blazorexpress.bulma.splitView.apply(instance);
        },
        instances: {},
        update: (elementId, options) => {
            const instance = window.blazorexpress.bulma.splitView.instances[elementId];
            if (!instance) {
                return;
            }

            instance.options = options;
            window.blazorexpress.bulma.splitView.apply(instance);

            if (instance.options.isDisabled && instance.dragging) {
                instance.onPointerUp();
            }
        }
    },
    scriptLoader: {
        initialize: (elementId, async, defer, scriptId, source, type, dotNetHelper) => {
            let scriptLoaderEl = document.getElementById(elementId);

            if (source.length === 0) {
                console.error(`Invalid src url.`);
                return;
            }

            let scriptEl = document.createElement('script');

            scriptEl.async = async;

            scriptEl.defer = defer;

            if (scriptId != null)
                scriptEl.id = scriptId;

            if (source != null)
                scriptEl.src = source;

            if (type != null)
                scriptEl.type = type;

            scriptEl.addEventListener("error", (event) => {
                dotNetHelper.invokeMethodAsync('OnErrorJS', `An error occurred while loading the script: ${source}`);
            });

            scriptEl.addEventListener("load", (event) => {
                dotNetHelper.invokeMethodAsync('OnLoadJS');
            });

            if (scriptLoaderEl != null)
                scriptLoaderEl.appendChild(scriptEl);
        }
    },
    utils: {
        focusElement(elementId) {
            const element = document.getElementById(elementId);
            if (element) {
                element.focus();
            }
        }
    }
}
