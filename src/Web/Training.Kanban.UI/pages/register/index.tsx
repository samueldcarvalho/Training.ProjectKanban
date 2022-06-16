/** @format */

import { GetServerSidePropsContext } from "next";
import RegisterForm from "../../src/components/login/RegisterForm";

const Register = () => {
  return (
    <div className="kb-login">
      <div className="kb-sign-body">
        <section className="kb-sign">
          <RegisterForm onSubmit={() => {}} />
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

export default Register;
