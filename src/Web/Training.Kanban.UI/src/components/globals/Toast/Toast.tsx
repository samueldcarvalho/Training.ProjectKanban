import { ToastProps, ToastType } from "../../../contexts/Toast/ToastContext";
import { MdError, MdInfo, MdWarning, MdCheckCircle } from "react-icons/md";
import styles from "./Toast.module.css";

const Toast = ({ toastList, removeToast }: { toastList: ToastProps[]; removeToast: (toast: ToastProps) => void }) => {
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

  return (
    <div className={styles.toastMainContainer}>
      {toastList.map((toast, i) => {
        const items = toastItems(toast.type);

        return (
          <div key={i} className={styles.toast + ` ${styles[items.colorClass]}`}>
            <div className={styles.toastIcon}>{items.icon}</div>
            <div className={styles.toastBody}>
              <p className={styles.toastTitle}>{toast.title}</p>
              <p className={styles.toastMessage}>{toast.message}</p>
            </div>
            <div className={styles.toastEnd}>
              <button
                onClick={() => {
                  removeToast(toast);
                }}
              >
                +
              </button>
            </div>
          </div>
        );
      })}
    </div>
  );
};

export default Toast;
