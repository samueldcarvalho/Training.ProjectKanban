import Router from "next/router";
import { parseCookies } from "nookies";
import { ReactNode, useLayoutEffect } from "react";

const ProtectedLayout = ({ children }: { children: ReactNode }) => {
  useLayoutEffect(() => {
    const { ["kanban.token"]: token } = parseCookies();

    console.log(token);

    if (token == undefined) {
      Router.push("/login");
      return;
    }
  }, []);

  return <>{children}</>;
};

export default ProtectedLayout;
