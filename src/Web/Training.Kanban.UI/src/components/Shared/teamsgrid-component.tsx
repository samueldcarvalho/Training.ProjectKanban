import { AiOutlineArrowRight } from "react-icons/ai";

const TeamGridComponent = (props: { teams: any }) => {
  return (
    <>
      <div>
        <tr className="row kb-table-row kb-table-row-header" style={{ width: "100%" }}>
          <td className="col">Name</td>
          <td className="col">Task Points</td>
        </tr>
      </div>
      {props.teams.map((team: any) => {
        return (
          <div>
            <tr className="row kb-table-row">
              <div>
                <AiOutlineArrowRight />
              </div>
              <td className="col">{team.name}</td>
              <td className="col">{team.taskpoints}</td>
            </tr>
          </div>
        );
      })}
    </>
  );
};

export default TeamGridComponent;
