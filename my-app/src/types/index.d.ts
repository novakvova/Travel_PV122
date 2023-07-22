export {};

declare global {
    interface Window {
        google: any;
        [key: string]: any;
    }
}