if (!window.blazorExpress) {
    window.blazorExpress = {};
}

window.blazorExpress = {
    menu: {
        initialize: (elementId, dotNetHelper) => {
            window.addEventListener("resize", () => {
                dotNetHelper.invokeMethodAsync('WindowResizeJS', window.innerWidth);
            });
        },
        windowSize: () => window.innerWidth
    },
    googlemaps: {
        addMarker: (elementId, marker, dotNetHelper) => {
            let mapInstance = window.blazorBootstrap.googlemaps.get(elementId);
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
                    _content.classList.add("bb-google-marker-content");
                    _content.innerHTML = marker.content;
                }

                const markerEl = new google.maps.marker.AdvancedMarkerElement({
                    map,
                    content: _content,
                    position: marker.position,
                    title: marker.title,
                    gmpClickable: clickable
                });

                window.blazorBootstrap.googlemaps.markerEls[elementId].push(markerEl);

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
            window.blazorBootstrap.googlemaps.instances[elementId] = {
                map: map,
                zoom: zoom,
                center: center,
                markers: markers,
                clickable: clickable
            };
        },
        get: (elementId) => {
            return window.blazorBootstrap.googlemaps.instances[elementId];
        },
        initialize: (elementId, zoom, center, markers, clickable, dotNetHelper) => {
            window.blazorBootstrap.googlemaps.markerEls[elementId] = window.blazorBootstrap.googlemaps.markerEls[elementId] ?? []

            let mapOptions = { center: center, zoom: zoom, mapId: elementId };
            let map = new google.maps.Map(document.getElementById(elementId), mapOptions);

            window.blazorBootstrap.googlemaps.create(elementId, map, zoom, center, markers, clickable);

            if (markers) {
                for (const marker of markers) {
                    window.blazorBootstrap.googlemaps.addMarker(elementId, marker, dotNetHelper);
                }
            }
        },
        instances: {},
        markerEls: {},
        updateMarkers: (elementId, markers, dotNetHelper) => {
            let markerEls = window.blazorBootstrap.googlemaps.markerEls[elementId] ?? [];

            // delete the markers
            if (markerEls.length > 0) {
                for (const markerEl of markerEls) {
                    markerEl.setMap(null);
                }
            }

            if (markers) {
                for (const marker of markers) {
                    window.blazorBootstrap.googlemaps.addMarker(elementId, marker, dotNetHelper);
                }
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
    }
}