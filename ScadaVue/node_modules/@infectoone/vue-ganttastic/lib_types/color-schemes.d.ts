import type { Color } from "csstype";
export declare type ColorScheme = {
    primary: Color;
    secondary: Color;
    ternary: Color;
    quartenary: Color;
    hoverHighlight: Color;
    text: Color;
    background: Color;
    toast?: Color;
};
export declare const colorSchemes: Record<string, ColorScheme>;
export declare type ColorSchemeKey = keyof typeof colorSchemes;
export default colorSchemes;
