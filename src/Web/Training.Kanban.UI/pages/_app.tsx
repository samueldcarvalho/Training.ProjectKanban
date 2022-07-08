import "../src/styles/bootstrap/bootstrap-grid.min.css";
import "../src/styles/globals.css";
import "../src/styles/login-module.css";

import type { AppProps } from "next/app";
import { AuthProvider } from "../src/contexts/Authentication/AuthContext";
import { LoadingProvider } from "../src/contexts/Loading/LoadingContext";
import { ToastProvider } from "../src/contexts/Toast/ToastContext";
import { CssBaseline, ThemeProvider, createTheme } from "@material-ui/core";

function MyApp({ Component, pageProps }: AppProps) {
  const theme = createTheme({
    palette: {
      primary: {
        main: "#263238",
        light: "#4f5b62",
        dark: "#000a12",
        contrastText: "#eeeeee",
      },
      secondary: {
        main: "#3d5afe",
        light: "#8187ff",
        dark: "#0031ca",
        contrastText: "#ffffff",
      },
    },
  });

  return (
    <ToastProvider>
      <LoadingProvider>
        <AuthProvider>
          <ThemeProvider theme={theme}>
            <CssBaseline>
              <Component {...pageProps} />;
            </CssBaseline>
          </ThemeProvider>
        </AuthProvider>
      </LoadingProvider>
    </ToastProvider>
  );
}

export default MyApp;
