import CardTitleComponent from "../src/components/main/titlecard-component";
import Wrapper from "../src/components/main/wrapper-component";
import { AiOutlineArrowRight } from "react-icons/ai"
import BoardCardComponent from "../src/components/shared/boardcard-component";
import TeamGridComponent from "../src/components/shared/teamsgrid-component";

export type User = {
    id: number;
    name: string;
    taskpoints: number;
    teams: Team[];
}

export type Team = {
    id: number;
    name: string;
    members?: { id: number, name: string, taskpoints: number, role: string }[];
    taskpoints: number;
}

export let user: User = {
    id: 1,
    name: "Samuel de Carvalho",
    taskpoints: 128,
    teams: [{
        id: 1,
        name: "Automatiza Sistemas",
        taskpoints: 102,
        members: [{
            id: 1,
            name: "Samuel de Carvalho",
            taskpoints: 64,
            role: "Leader"
        },
        {
            id: 2,
            name: "Diego Silveira",
            taskpoints: 24,
            role: "Officer"
        },
        {
            id: 3,
            name: "Jessica Penegrini Alves",
            taskpoints: 32,
            role: "Officer"
        },
        {
            id: 4,
            name: "Marianne Schultz",
            taskpoints: 5,
            role: "Officer"
        },
        {
            id: 5,
            name: "Carlos Tevez",
            taskpoints: 4,
            role: "Coordenator"
        },
        {
            id: 6,
            name: "Joana Pereira Gonçalves",
            taskpoints: 7,
            role: "Officer"
        }]
    },
    {
        id: 2,
        name: "CodeCannon",
        taskpoints: 26,
        members: [{
            id: 1,
            name: "Samuel de Carvalho",
            taskpoints: 26,
            role: "Leader"
        }]
    }]
};;

const Home = () => {
    return (
        <Wrapper titlePagePops={{ title: "Home", description: "Welcome" }}>
            <div className="kb-card kb-home-top">
                <div className="kb-home-header">
                    <div className="kb-home-header-top">
                        <p>Greetings, {user.name}!</p>
                        <p>Welcome to your favorite Kanban App</p>
                    </div>
                </div>
            </div>
            <div className="kb-card kb-home-teams">
                <div className="kb-home-teams-header">
                    <CardTitleComponent title="Your Teams" description="Select one to look more details:" align="flex-start" />
                </div>
                <div className="kb-home-teams-body">
                    <TeamGridComponent teams={user.teams} />
                </div>
            </div>
            <div className="kb-card kb-home-boards">
                <div className="kb-home-boards-header">
                    <CardTitleComponent title="Your Boards" description="Below, all your boards as you are member. Select one to access." align="flex-start" />
                </div>
                <div className="kb-home-boards-body">
                    <BoardCardComponent membersCount={8} boardName="Desenvolvimento" boardColor="#65a300" />
                    <BoardCardComponent membersCount={21} boardName="Suporte" boardColor="#65a300" />
                    <BoardCardComponent membersCount={1} boardName="Pessoal" boardColor="#65a300" />
                </div>
            </div>
        </Wrapper >
    )
}

export default Home;
