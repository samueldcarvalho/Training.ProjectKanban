import Wrapper from "../../src/components/main/wrapper-component";
import { ProtectedLayout } from "../../src/components/ProtectedLayout";

const BoardsPage = () => {
    return (
        <ProtectedLayout>
            <Wrapper titlePagePops={{ title: "Boards", description: "Sell all" }}>
                <div>

                </div>
            </Wrapper>
        </ProtectedLayout>
    );
}

export default BoardsPage;
