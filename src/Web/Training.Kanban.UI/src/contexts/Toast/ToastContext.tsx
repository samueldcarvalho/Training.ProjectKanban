import { createContext, ReactNode, useCallback, useState } from "react";
import Toast from "../../components/globals/Toast/ToastContainer";

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

    toast.id = toastList.length + 1;

    setToastList([...toastList, toast]);
  }

  function clearToast() {
    setToastList([]);
  }

  const deleteToast = useCallback(
    (id) => {
      console.log(id);
      const toastListRemovedItem = toastList.filter((t) => t.id !== id);
      setToastList(toastListRemovedItem);
    },
    [toastList, setToastList]
  );

  return (
    <ToastContext.Provider value={{ useToast, clearToast, deleteToast }}>
      <Toast toastList={toastList} />
      {children}
    </ToastContext.Provider>
  );
};
