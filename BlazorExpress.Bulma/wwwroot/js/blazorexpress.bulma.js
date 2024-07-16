
//// THEMES
//const STORAGE_KEY = "bulma-theme";
//const SYSTEM_THEME = "system";
//const DEFAULT_THEME = "light";

//const state = {
//    chosenTheme: SYSTEM_THEME, // light|dark|system
//    appliedTheme: DEFAULT_THEME, // light|dark
//    OSTheme: null, // light|dark|null
//};

//const $themeCycle = document.getElementById("js-cycle");
//const $themeSwitchers = document.querySelectorAll(".js-themes .js-theme-item");
//const $darkmodes = document.querySelectorAll(".js-darkmode");

//const updateThemeUI = () => {
//    if (state.appliedTheme === "light") {
//        $themeCycle.className = "bd-cycle js-burger is-sun";
//    } else {
//        $themeCycle.className = "bd-cycle js-burger is-moon";
//    }

//    $themeSwitchers.forEach((el) => {
//        const swatchTheme = el.dataset.scheme;

//        if (state.chosenTheme === swatchTheme) {
//            el.classList.add("is-active");
//        } else {
//            el.classList.remove("is-active");
//        }
//    });
//};

//const setTheme = (theme, save = true) => {
//    state.chosenTheme = theme;
//    state.appliedTheme = theme;

//    if (theme === SYSTEM_THEME) {
//        state.appliedTheme = state.OSTheme;
//        document.documentElement.removeAttribute("data-theme");
//        window.localStorage.removeItem(STORAGE_KEY);
//    } else {
//        document.documentElement.setAttribute("data-theme", theme);

//        if (save) {
//            window.localStorage.setItem(STORAGE_KEY, theme);
//        }
//    }

//    updateThemeUI();
//};

//const toggleTheme = () => {
//    if (state.appliedTheme === "light") {
//        setTheme("dark");
//    } else {
//        setTheme("light");
//    }
//};

//const detectOSTheme = () => {
//    if (!window.matchMedia) {
//        // matchMedia method not supported
//        return DEFAULT_THEME;
//    }

//    if (window.matchMedia("(prefers-color-scheme: dark)").matches) {
//        // OS theme setting detected as dark
//        return "dark";
//    } else if (window.matchMedia("(prefers-color-scheme: light)").matches) {
//        return "light";
//    }

//    return DEFAULT_THEME;
//};

//// On load, check if any preference was saved
//const localTheme = window.localStorage.getItem(STORAGE_KEY);
//state.OSTheme = detectOSTheme();

//if (localTheme) {
//    setTheme(localTheme, false);
//} else {
//    setTheme(SYSTEM_THEME);
//}

//// Event listeners
//$themeSwitchers.forEach((el) => {
//    el.addEventListener("click", () => {
//        const theme = el.dataset.scheme;
//        setTheme(theme);
//    });
//});

//$darkmodes.forEach((el) => {
//    el.addEventListener("click", (e) => {
//        e.preventDefault();
//        toggleTheme();
//    });
//});

//window
//    .matchMedia("(prefers-color-scheme: dark)")
//    .addEventListener("change", (event) => {
//        const theme = event.matches ? "dark" : "light";
//        state.OSTheme = theme;
//        setTheme(theme);
//    });
