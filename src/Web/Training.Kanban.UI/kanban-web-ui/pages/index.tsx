import CardTitleComponent from "../components/main/titlecard-component";
import Wrapper from "../components/main/wrapper-component";

type User = {
    id: number;
    name: string;
    taskpoints: number;
    teams: Team[];
}

type Team = {
    id: number;
    name: string;
    taskpoints: number;
}

const Home = () => {

    let user: User = {
        id: 1,
        name: "Samuel de Carvalho",
        taskpoints: 128,
        teams: [{
            id: 1,
            name: "Automatiza Sistemas",
            taskpoints: 102,
        },
        {
            id: 2,
            name: "CodeCannon",
            taskpoints: 26
        }]
    };

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
                    <CardTitleComponent title="Your Teams" description="Select one to look more details:" />
                </div>
                <div className="kb-home-teams-body">
                    <div>
                        <tr className="row kb-table-header" style={{ width: "100%" }}>
                            <td className="col">Name</td>
                            <td className="col">Taskpoints</td>
                        </tr>
                    </div>
                    {
                        user.teams.map(team => {
                            return (
                                <div>
                                    <tr className="row kb-table-row">
                                        <td className="col">{team.name}</td>
                                        <td className="col">{team.taskpoints}</td>
                                    </tr>
                                </div>
                            )
                        })
                    }
                </div>
            </div>
            <div className="kb-card kb-home-boards">
            </div>
        </Wrapper >
    )
}

export default Home;
