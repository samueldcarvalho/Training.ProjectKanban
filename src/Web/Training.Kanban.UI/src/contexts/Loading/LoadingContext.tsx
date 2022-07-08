import { createContext, ReactNode, useState } from "react";
import LoadingModal from "../../components/LoadingModal/LoadingModal";

type LoadingType = {
  isLoading: boolean;
  loadingText: string;
};

type LoadingContext = {
  isLoading: boolean;
  loadingText: string;
  LoadingHandler: (loadState: LoadingType) => void;
};

export const LoadingContext = createContext({} as LoadingContext);

export const LoadingProvider = ({ children }: { children: ReactNode }) => {
  const [loadingState, setLoadingState] = useState<LoadingType>({ isLoading: false, loadingText: "" });

  return (
    <LoadingContext.Provider
      value={{
        isLoading: loadingState.isLoading,
        loadingText: loadingState.loadingText,
        LoadingHandler: setLoadingState,
      }}
    >
      <LoadingModal isLoading={loadingState.isLoading} loadingText={loadingState.loadingText} />
      {children}
    </LoadingContext.Provider>
  );
};
