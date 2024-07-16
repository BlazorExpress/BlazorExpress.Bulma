async function copyToClipboard(text, dotNetHelper) {
    let isCopied = true;

    try {
        await navigator.clipboard.writeText(text);
        dotNetHelper.invokeMethodAsync('OnCopySuccessJS');
    } catch (err) {
        isCopied = false;
        dotNetHelper.invokeMethodAsync('OnCopyFailJS', err);
    }

    setTimeout(
        () => { dotNetHelper.invokeMethodAsync('ResetCopyStatusJS'); },
        isCopied ? 2000 : 3000
    );
}

function highlightCode() {
    if (Prism) {
        Prism.highlightAll();
    }
};

function navigateToHeading() {
    if (window.location.hash) {
        // get hash tag in URL
        let hashTagName = window.location.hash.substring(1);
        let el = document.getElementById(hashTagName);
        if (el) {
            // do the scroll
            el.scrollIntoView();
        }
    }
}


// THEMES
const STORAGE_KEY = "bulma-theme";
const SYSTEM_THEME = "system";
const DEFAULT_THEME = "light";

const state = {
    chosenTheme: SYSTEM_THEME,
    appliedTheme: DEFAULT_THEME,
    OSTheme: null,
};

const updateThemeUI = () => {
        let $themeIndicator = document.querySelector(".be-theme-indicator i");
    if (state.appliedTheme === "light") {
        $themeIndicator.className = "bi bi-sun";
    } else {
        $themeIndicator.className = "bi bi-moon-stars-fill";
    }

    let $themeSwitchers = document.querySelectorAll(".be-theme-item");
    $themeSwitchers.forEach((el) => {
        const swatchTheme = el.dataset.scheme;
        if (state.chosenTheme === swatchTheme) {
            el.classList.add("is-selected");
        } else {
            el.classList.remove("is-selected");
        }
    });
};

function setTheme(theme, save = true) {
    state.chosenTheme = theme;
    state.appliedTheme = theme;

    if (theme === SYSTEM_THEME) {
        state.appliedTheme = state.OSTheme;
        document.documentElement.removeAttribute("data-theme");
        window.localStorage.removeItem(STORAGE_KEY);
    } else {
        document.documentElement.setAttribute("data-theme", theme);

        if (save) {
            window.localStorage.setItem(STORAGE_KEY, theme);
        }
    }

    updateThemeUI();
};

const toggleTheme = () => {
    if (state.appliedTheme === "light") {
        setTheme("dark");
    } else {
        setTheme("light");
    }
};

const detectOSTheme = () => {
    if (!window.matchMedia) {
        // matchMedia method not supported
        return DEFAULT_THEME;
    }

    if (window.matchMedia("(prefers-color-scheme: dark)").matches) {
        // OS theme setting detected as dark
        return "dark";
    } else if (window.matchMedia("(prefers-color-scheme: light)").matches) {
        return "light";
    }

    return DEFAULT_THEME;
};

// On load, check if any preference was saved
const localTheme = window.localStorage.getItem(STORAGE_KEY);
state.OSTheme = detectOSTheme();

if (localTheme) {
    setTheme(localTheme, false);
} else {
    setTheme(SYSTEM_THEME);
}

window
    .matchMedia("(prefers-color-scheme: dark)")
    .addEventListener("change", (event) => {
        const theme = event.matches ? "dark" : "light";
        state.OSTheme = theme;
        setTheme(theme);
    });
