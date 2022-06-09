import LoaderSpinning from "../../src/components/globals/Loading/Spinner/LoaderSpinning";
import Wrapper from "../../src/components/main/wrapper-component";
import ProtectedLayout from "../../src/components/Security/ProtectedLayout";

const BoardsPage = () => {
  return (
    <ProtectedLayout>
      <Wrapper titlePagePops={{ title: "Boards", description: "Sell all" }}>
        <div>
          <LoaderSpinning></LoaderSpinning>
        </div>
      </Wrapper>
    </ProtectedLayout>
  );
};

export default BoardsPage;
