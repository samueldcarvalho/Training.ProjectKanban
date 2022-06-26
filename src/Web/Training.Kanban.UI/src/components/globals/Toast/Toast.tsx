import { ToastContext, ToastProps, ToastType } from "../../../contexts/Toast/ToastContext";
import { MdError, MdInfo, MdWarning, MdCheckCircle } from "react-icons/md";
import styles from "./Toast.module.css";
import { useContext, useState } from "react";

const Toast = ({ toast }: { toast: ToastProps }) => {
  const { deleteToast } = useContext(ToastContext);

  const toastItems = (type: ToastType) => {
    let colorClass;
    let icon;
    const iconSize = { width: "25px", height: "25px" };
    switch (type) {
      case ToastType.Danger:
        colorClass = "danger";
        icon = <MdError style={iconSize} />;
        break;
      case ToastType.Info:
        colorClass = "info";
        icon = <MdInfo style={iconSize} />;
        break;
      case ToastType.Success:
        colorClass = "success";
        icon = <MdCheckCircle style={iconSize} />;
        break;
      case ToastType.Warning:
        colorClass = "warning";
        icon = <MdWarning style={iconSize} />;
        break;
    }
    return { colorClass, icon };
  };

  const [toastElements] = useState<{ colorClass: string; icon: JSX.Element }>(toastItems(toast.type));

  return (
    <div key={toast.id} className={styles.toast + ` ${styles[toastElements.colorClass]}`}>
      <div className={styles.toastIcon}>{toastElements.icon}</div>
      <div className={styles.toastBody}>
        <p className={styles.toastTitle}>{toast.title}</p>
        <p className={styles.toastMessage}>{toast.message}</p>
      </div>
      <div className={styles.toastEnd}>
        <button
          onClick={() => {
            deleteToast(toast.id!);
          }}
        >
          +
        </button>
      </div>
    </div>
  );
};

export default Toast;
