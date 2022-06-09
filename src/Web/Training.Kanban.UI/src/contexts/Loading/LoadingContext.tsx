import { createContext, ReactNode, useState } from "react";
import LoadingModal from "../../components/globals/Loading/Modal/LoadingModal";

type LoadingContext = {
  isLoading: boolean;
  setLoading: (load: boolean) => void;
};

export const LoadingContext = createContext({} as LoadingContext);

export const LoadingProvider = ({ children }: { children: ReactNode }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const setLoadingHandler = (load: boolean) => {
    if (isLoading == load) return;

    setIsLoading(load);
  };

  return (
    <LoadingContext.Provider
      value={{
        isLoading,
        setLoading: setLoadingHandler,
      }}
    >
      <LoadingModal isLoading={isLoading} />
      {children}
    </LoadingContext.Provider>
  );
};
