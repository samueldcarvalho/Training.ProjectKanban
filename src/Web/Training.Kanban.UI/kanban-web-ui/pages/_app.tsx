import '../styles/bootstrap/bootstrap-grid.min.css'
import '../styles/globals.css'
import '../styles/login-module.css'
import '../styles/main-module.css'

import type { AppProps } from 'next/app'

function MyApp({ Component, pageProps }: AppProps) {
  return <Component {...pageProps} />
}

export default MyApp
