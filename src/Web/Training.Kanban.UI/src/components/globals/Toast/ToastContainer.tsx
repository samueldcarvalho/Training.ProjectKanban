import { ToastProps } from "../../../contexts/Toast/ToastContext";
import styles from "./Toast.module.css";
import Toast from "./Toast";

const ToastContainer = ({ toastList }: { toastList: ToastProps[] }) => {
  return (
    <div className={styles.toastMainContainer}>
      {toastList.map((toast) => (
        <Toast toast={toast} />
      ))}
    </div>
  );
};

export default ToastContainer;
