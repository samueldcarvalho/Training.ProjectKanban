import styles from "./modal.module.css";
import { ReactNode } from "react";

const ModalGeneric = ({ children }: { children: ReactNode }) => {
  return <div className={styles.kb_modal_overlay}>{children}</div>;
};

export default ModalGeneric;
