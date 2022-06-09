import Router from "next/router";
import { parseCookies } from "nookies";
import { ReactNode, useEffect } from "react";

const ProtectedLayout = ({ children }: { children: ReactNode }) => {
  useEffect(() => {
    const { ["kanban.token"]: token } = parseCookies();

    if (token == undefined) {
      Router.push("/login");
      return;
    }
  }, []);

  return <>{children}</>;
};

export default ProtectedLayout;
