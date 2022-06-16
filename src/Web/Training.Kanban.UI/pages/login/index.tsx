/** @format */

import { GetServerSidePropsContext } from "next";
import Link from "next/link";
import { useContext } from "react";
import LoginForm from "../../src/components/login/LoginForm";
import { AuthContext } from "../../src/contexts/Authentication/AuthContext";

const Login = () => {
  const { Authenticate } = useContext(AuthContext);

  async function onSubmitHandler(username: string, password: string) {
    await Authenticate({ username, password });
  }

  return (
    <div className="kb-login">
      <div className="kb-sign-body">
        <section className="kb-sign">
          <div className="kb-sign-change-form">
            <span>
              <p>
                You don't have <br /> an account?
              </p>
              <Link href="/register">
                <a className="kb-secundary-button">Create!</a>
              </Link>
            </span>
          </div>
          <LoginForm onSubmit={onSubmitHandler} />
        </section>
      </div>
    </div>
  );
};

export const getServerSideProps = ({ req }: GetServerSidePropsContext) => {
  const { ["kanban.token"]: token } = req.cookies;

  if (token)
    return {
      redirect: {
        permanent: false,
        destination: "/",
      },
      props: {},
    };

  return {
    props: {},
  };
};

export default Login;
