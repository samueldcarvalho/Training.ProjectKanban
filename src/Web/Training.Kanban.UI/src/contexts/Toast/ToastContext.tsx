import { createContext, ReactNode, useState } from "react";
import Toast from "../../components/globals/Toast/Toast";

export enum ToastType {
  Success,
  Info,
  Warning,
  Danger,
}

type ToastContextType = {
  useToast: (toast: ToastProps) => void;
  clearToast: () => void;
};

export type ToastProps = {
  id?: number;
  type: ToastType;
  message: string;
  title?: string;
  delay?: number;
};

export const ToastContext = createContext({} as ToastContextType);

export const ToastProvider = ({ children }: { children: ReactNode }) => {
  const [toastList, setToastList] = useState<Array<ToastProps>>([]);

  function useToast(toast: ToastProps) {
    if (!toast.title) toast.title = "";
    if (!toast.id) toast.id = 0;

    console.log(toastList);

    const lastId =
      toastList.length == 0
        ? 0
        : toastList?.reduce((prev, current) => {
            return prev.id! > current.id! ? prev : current;
          }).id;

    toast.id = !lastId ? 1 : lastId + 1;

    console.log(toast.id);

    setToastList([...toastList, toast]);

    if (toast.delay != null || toast.delay! > 0)
      setTimeout(() => {
        console.log("REMOVED");
        setToastList([...toastList.filter((a) => a.id != toast.id)]);
      }, toast.delay);
  }

  function clearToast() {
    setToastList([]);
  }

  return (
    <ToastContext.Provider value={{ useToast, clearToast }}>
      <Toast
        toastList={toastList}
        removeToast={(toast: ToastProps) => setToastList([...toastList.filter((a) => a.id != toast.id)])}
      />
      {children}
    </ToastContext.Provider>
  );
};
