import { useState } from "react";
import { Team, user } from "..";
import CardTitleComponent from "../../components/main/titlecard-component";
import Wrapper from "../../components/main/wrapper-component";

const TeamsPage = () => {

    const [selectedTeam, setSelectedTeam] = useState<Team>();

    const SelectTeamHandle = (team: Team) => setSelectedTeam(team);

    return (
        <Wrapper titlePagePops={{ title: "Teams", description: "management" }}>
            <div className="kb-card kb-teams-top">
                <div className="kb-teams-top-header">
                    <CardTitleComponent title="Details" description="See more details below" />
                </div>
                <div className="kb-teams-top-body">
                    <div>
                        <tr className="row kb-table-row kb-table-row-header" style={{ width: "100%" }}>
                            <td className="col">Name</td>
                            <td className="col">Task Points</td>
                        </tr>

                        {user.teams.length > 0 ? user.teams.map(team => {
                            return (
                                <div onClick={() => SelectTeamHandle(team)}>
                                    <tr className="row kb-table-row">
                                        <td className="col">{team.name}</td>
                                        <td className="col">{team.taskpoints}</td>
                                    </tr>
                                </div>
                            )
                        }) : (<div>Sem dados</div>)}
                    </div>
                </div>
            </div>
            <div className="kb-card kb-teams-body">
                <div className="kb-teams-body-header">
                    <CardTitleComponent title="Members" description="Below you can see all members of the selected team " />
                </div>
                <div className="kb-teams-body-body">
                    <div>
                        <tr className="row kb-table-row kb-table-row-header" style={{ width: "100%" }}>
                            <td className="col">Id</td>
                            <td className="col">Name</td>
                            <td className="col">Task Points</td>
                            <td className="col">Role</td>
                        </tr>
                    </div>
                </div>
                {selectedTeam == null ? <>Sem dados</> :
                    selectedTeam.members?.map(member => {
                        return (
                            <div>
                                <tr className="row kb-table-row">
                                    <td className="col">{member.id}</td>
                                    <td className="col">{member.name}</td>
                                    <td className="col">{member.taskpoints}</td>
                                    <td className="col">{member.role}</td>
                                </tr>
                            </div>
                        )
                    })}
            </div>
        </Wrapper>
    );
}

export default TeamsPage;
