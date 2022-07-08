import CardTitleComponent from "../src/components/main/titlecard-component";
import Wrapper from "../src/components/main/wrapper-component";
import BoardCardComponent from "../src/components/Shared/boardcard-component";
import { useContext } from "react";
import { AuthContext } from "../src/contexts/Authentication/AuthContext";
import { GetServerSidePropsContext } from "next";

const Home = () => {
  const { user } = useContext(AuthContext);

  return <Wrapper titlePagePops={{ title: "Home", description: "Welcome" }}></Wrapper>;
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

export default Home;
