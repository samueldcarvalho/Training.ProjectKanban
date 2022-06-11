import { GetServerSidePropsContext } from "next";
import { useState } from "react";
import { Team } from "..";
import Modal from "../../src/components/main/Modal/Modal";
import CardTitleComponent from "../../src/components/main/titlecard-component";
import Wrapper from "../../src/components/main/wrapper-component";

const TeamsPage = () => {
  const [selectedTeam, setSelectedTeam] = useState<Team>({
    id: 0,
    name: "Dev",
    taskpoints: 123,
    members: [
      {
        id: 1,
        name: "Sam",
        role: "Leader",
        taskpoints: 123,
      },
    ],
  });
  const [modalIsOpen, setModalIsOpen] = useState(false);

  const SelectTeamHandle = (team: Team) => setSelectedTeam(team);

  return (
    <Wrapper titlePagePops={{ title: "Teams", description: "management" }}>
      <div className="kb-card kb-teams-top">
        <div className="kb-teams-top-header">
          <CardTitleComponent align="flex-start" title="Details" description="See more details below" />
        </div>
        <div className="kb-teams-top-body">
          <div className="kb-teams-top-body-grid">
            <tr className="row kb-table-row kb-table-row-header" style={{ width: "100%" }}>
              <td className="col">Name</td>
              <td className="col">Task Points</td>
            </tr>

            <div onClick={() => {}}>
              <tr className={"row row kb-table-row kb-table-row-selected"}>
                <td className="col">{selectedTeam.name}</td>
                <td className="col">{selectedTeam.taskpoints}</td>
              </tr>
            </div>
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
            <tr className="row kb-table-row kb-table-row-header" style={{ width: "100%" }}>
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

export default TeamsPage;
