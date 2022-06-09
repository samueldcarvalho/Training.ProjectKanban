import CardTitleComponent from "../src/components/main/titlecard-component";
import Wrapper from "../src/components/main/wrapper-component";
import BoardCardComponent from "../src/components/Shared/boardcard-component";
import { ProtectedLayout } from "../src/components/ProtectedLayout";
import { useContext } from "react";
import { AuthContext } from "../src/contexts/Authentication/AuthContext";

export type User = {
  id: number;
  name: string;
  taskpoints: number;
  teams: Team[];
};

export type Team = {
  id: number;
  name: string;
  members?: { id: number; name: string; taskpoints: number; role: string }[];
  taskpoints: number;
};

const Home = () => {
  const { user } = useContext(AuthContext);

  return (
    <ProtectedLayout>
      <Wrapper titlePagePops={{ title: "Home", description: "Welcome" }}>
        <div className="kb-card kb-home-top">
          <div className="kb-home-header">
            <div className="kb-home-header-top">
              <p>Greetings, {user?.name}!</p>
              <p>Welcome to your favorite Kanban App</p>
            </div>
          </div>
        </div>
        <div className="kb-card kb-home-teams">
          <div className="kb-home-teams-header">
            <CardTitleComponent title="Your Teams" description="Select one to look more details:" align="flex-start" />
          </div>
          <div className="kb-home-teams-body">{/* <TeamGridComponent teams={""} /> */}</div>
        </div>
        <div className="kb-card kb-home-boards">
          <div className="kb-home-boards-header">
            <CardTitleComponent
              title="Your Boards"
              description="Below, all your boards as you are member. Select one to access."
              align="flex-start"
            />
          </div>
          <div className="kb-home-boards-body">
            <BoardCardComponent membersCount={8} boardName="Desenvolvimento" boardColor="#65a300" />
          </div>
        </div>
      </Wrapper>
    </ProtectedLayout>
  );
};

export default Home;
