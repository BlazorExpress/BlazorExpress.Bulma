if (!window.blazorExpress) {
    window.blazorExpress = {};
}

window.blazorExpress = {
    menu: {
        initialize: (elementId, dotNetHelper) => {
            window.addEventListener("resize", () => {
                dotNetHelper.invokeMethodAsync('WindowResizeJS', screen.width);
            });
        },
        windowSize: () => screen.width
    }
}