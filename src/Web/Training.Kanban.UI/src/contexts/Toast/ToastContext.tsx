import { createContext, ReactNode, useCallback, useState } from "react";
import Toast from "../../components/Toast/ToastContainer";

export enum ToastType {
  Success,
  Info,
  Warning,
  Danger,
}

type ToastContextType = {
  useToast: (toast: ToastProps) => void;
  clearToast: () => void;
  deleteToast: (id: number) => void;
};

export type ToastProps = {
  id?: number;
  type: ToastType;
  message: string;
  title?: string;
};

export const ToastContext = createContext({} as ToastContextType);

export const ToastProvider = ({ children }: { children: ReactNode }) => {
  const [toastList, setToastList] = useState<Array<ToastProps>>([]);

  function useToast(toast: ToastProps) {
    if (!toast.title) toast.title = "";
    if (!toast.id) toast.id = 0;

    if (toastList.length <= 0) {
      toast.id = 1;
    } else {
      const ids = toastList.map((t) => t.id!);
      toast.id = Math.max(...ids) + 1;
    }

    toastList.push(toast);

    setToastList(toastList);
  }

  function clearToast() {
    setToastList(toastList.splice(0, toastList.length));
  }

  const deleteToast = useCallback(
    (id: number) => {
      const toastListRemovedItem = toastList.filter((t) => t.id !== id);

      setToastList(toastListRemovedItem);
    },
    [toastList]
  );

  return (
    <ToastContext.Provider value={{ useToast, clearToast, deleteToast }}>
      <Toast toastList={toastList} />
      {children}
    </ToastContext.Provider>
  );
};
