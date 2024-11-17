import useLocalStorage from "use-local-storage";

import "./App.css";
import { Toggle } from "./components/Toggle";
import { HomePage } from "./pages/HomePage"

export const App = () => {
    const preference = window.matchMedia("(prefers-color-scheme: dark)").matches;
    const [isDark, setIsDark] = useLocalStorage("isDark", preference);

    return (
        <div className="App" data-theme={isDark ? "dark" : "light"}>
            <Toggle isChecked={isDark} handleChange={() => setIsDark(!isDark)} />
            <HomePage/>
        </div>
    );
};