import { useContext, useEffect } from "react";
import Wrapper from "../../src/components/main/wrapper-component";
import ProtectedLayout from "../../src/components/Security/ProtectedLayout";
import { LoadingContext } from "../../src/contexts/Loading/LoadingContext";

const BoardsPage = () => {
  const { LoadingHandler } = useContext(LoadingContext);
  useEffect(() => {
    LoadingHandler({
      isLoading: true,
      loadingText: "Authenticating",
    });

    setTimeout(() => {
      LoadingHandler({
        isLoading: false,
        loadingText: "",
      });
    }, 1000);
  }, []);

  return (
    <ProtectedLayout>
      <Wrapper titlePagePops={{ title: "Boards", description: "Sell all" }}>
        <div></div>
      </Wrapper>
    </ProtectedLayout>
  );
};

export default BoardsPage;
