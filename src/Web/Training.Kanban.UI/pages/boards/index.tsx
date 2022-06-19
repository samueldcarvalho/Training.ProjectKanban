import { GetServerSidePropsContext } from "next";
import { useContext, useEffect } from "react";
import Wrapper from "../../src/components/main/wrapper-component";
import { AuthContext } from "../../src/contexts/Authentication/AuthContext";

const BoardsPage = () => {
  const { Logout } = useContext(AuthContext);

  useEffect(() => {
    Logout();
  }, []);

  return (
    <Wrapper titlePagePops={{ title: "Boards", description: "Sell all" }}>
      <div></div>
    </Wrapper>
  );
};

export const getServerSideProps = ({ req }: GetServerSidePropsContext) => {
  const { ["kanban.token"]: token } = req.cookies;

  if (!token)
    return {
      redirect: {
        permanent: false,
        destination: "/login",
      },
      props: {},
    };

  return {
    props: {},
  };
};

export default BoardsPage;
