import ModalGeneric from "../../../main/ModalGeneric/ModalGeneric";
import LoaderSpinning from "../Spinner/LoaderSpinning";

type LoadingModalProps = {
  isLoading: boolean;
};

const LoadingModal = ({ isLoading }: LoadingModalProps) => {
  return isLoading == true ? (
    <ModalGeneric>
      <div>
        <div>
          <LoaderSpinning />
          <div></div>
        </div>
      </div>
    </ModalGeneric>
  ) : (
    <></>
  );
};

export default LoadingModal;
