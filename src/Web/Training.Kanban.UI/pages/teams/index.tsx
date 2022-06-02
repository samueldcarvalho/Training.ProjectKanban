import { useState } from "react";
import { Team, user } from "..";
import Modal from "../../src/components/main/Modal/Modal";
import CardTitleComponent from "../../src/components/main/titlecard-component";
import Wrapper from "../../src/components/main/wrapper-component";
import { ProtectedLayout } from "../../src/components/ProtectedLayout";

const TeamsPage = () => {
  const [selectedTeam, setSelectedTeam] = useState<Team>(user.teams[0]!);
  const [modalIsOpen, setModalIsOpen] = useState(false);

  const SelectTeamHandle = (team: Team) => setSelectedTeam(team);

  return (
    <ProtectedLayout>
      <Wrapper titlePagePops={{ title: "Teams", description: "management" }}>
        <div className="kb-card kb-teams-top">
          <div className="kb-teams-top-header">
            <CardTitleComponent
              align="flex-start"
              title="Details"
              description="See more details below"
            />
          </div>
          <div className="kb-teams-top-body">
            <div className="kb-teams-top-body-grid">
              <tr
                className="row kb-table-row kb-table-row-header"
                style={{ width: "100%" }}
              >
                <td className="col">Name</td>
                <td className="col">Task Points</td>
              </tr>

              {user.teams.length > 0 ? (
                user.teams.map((team) => {
                  return (
                    <div onClick={() => SelectTeamHandle(team)}>
                      <tr
                        className={
                          team == selectedTeam
                            ? "row row kb-table-row kb-table-row-selected"
                            : "row kb-table-row"
                        }
                      >
                        <td className="col">{team.name}</td>
                        <td className="col">{team.taskpoints}</td>
                      </tr>
                    </div>
                  );
                })
              ) : (
                <div className="no-data-grid">
                  <h1>Sem dados</h1>
                </div>
              )}
            </div>
          </div>
          <div className="kb-teams-top-footer">
            <button
              className="kb-action-button kb-fly-button"
              onClick={() => {
                setModalIsOpen(!modalIsOpen);
              }}
            >
              +
            </button>
          </div>
        </div>
        <div className="kb-card kb-teams-body">
          <div className="kb-teams-body-header">
            <CardTitleComponent
              title="Members"
              description="Below you can see all members of the selected team "
              align="flex-start"
            />
          </div>
          <div className="kb-teams-body-body">
            <div>
              <tr
                className="row kb-table-row kb-table-row-header"
                style={{ width: "100%" }}
              >
                <td className="col">Id</td>
                <td className="col">Name</td>
                <td className="col">Task Points</td>
                <td className="col">Role</td>
              </tr>
            </div>
          </div>
          {selectedTeam == null ? (
            <div className="no-data-grid">
              <h1>Sem dados</h1>
            </div>
          ) : (
            selectedTeam.members?.map((member) => {
              return (
                <div>
                  <tr className="row kb-table-row">
                    <td className="col">{member.id}</td>
                    <td className="col">{member.name}</td>
                    <td className="col">{member.taskpoints}</td>
                    <td className="col">{member.role}</td>
                  </tr>
                </div>
              );
            })
          )}
          <button className="kb-action-button kb-fly-button">+</button>
        </div>
        {modalIsOpen && (
          <Modal
            title="Create a new team"
            onCloseHandler={() => {
              setModalIsOpen(!modalIsOpen);
            }}
          >
            <>
              <label className="kb-input-text-label">
                <p>Team's Name</p>
                <input type="text" className="kb-input-text" />
              </label>
              <label className="kb-input-text-label">
                <p>Team's Name</p>
                <input type="text" className="kb-input-text" />
              </label>
              <label className="kb-input-text-label">
                <p>Team's Name</p>
                <input type="text" className="kb-input-text" />
              </label>
              <label className="kb-input-text-label">
                <p>Team's Name</p>
                <input type="text" className="kb-input-text" />
              </label>
              <label className="kb-input-text-label">
                <p>Team's Name</p>
                <input type="text" className="kb-input-text" />
              </label>
              <label className="kb-input-text-label">
                <p>Team's Name</p>
                <input type="text" className="kb-input-text" />
              </label>
              <div className="kb-new-team-footer">
                <button className="kb-primary-button">Create</button>
              </div>
            </>
          </Modal>
        )}
      </Wrapper>
    </ProtectedLayout>
  );
};

export default TeamsPage;
