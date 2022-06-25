import "../src/styles/bootstrap/bootstrap-grid.min.css";
import "../src/styles/globals.css";
import "../src/styles/login-module.css";
import "../src/styles/main-module.css";
import "../src/styles/teams-module.css";

import type { AppProps } from "next/app";
import { AuthProvider } from "../src/contexts/Authentication/AuthContext";
import { LoadingProvider } from "../src/contexts/Loading/LoadingContext";
import { ToastProvider } from "../src/contexts/Toast/ToastContext";

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <ToastProvider>
      <LoadingProvider>
        <AuthProvider>
          <Component {...pageProps} />;
        </AuthProvider>
      </LoadingProvider>
    </ToastProvider>
  );
}

export default MyApp;
