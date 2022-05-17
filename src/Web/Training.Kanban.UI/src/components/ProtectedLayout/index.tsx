import { useAuth } from "../../context/AuthProvider/useAuth"

export const ProtectedLayout = ({ children }: { children: JSX.Element }) => {
    const auth = useAuth();

    if (!auth.username) {
        return <>You don't have access</>
    }


    return children;
}
