import { MdWarning } from "react-icons/md";
import styles from "./InvalidInputMessage.module.css";

const InvalidInputMessage = ({ message }: { message: string }) => {
  return (
    <div className={styles.formValidationSpan}>
      <MdWarning fill="#ff365e" />
      <p>{message}</p>
    </div>
  );
};

export default InvalidInputMessage;
