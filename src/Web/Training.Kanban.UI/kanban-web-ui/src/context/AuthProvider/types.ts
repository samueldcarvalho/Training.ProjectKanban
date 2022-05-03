export interface IUser {
    username? : string,
    nome?: string,
    token?: string,
}

export interface IContext extends IUser{
    Authenticate: (email: string, password: string) => 
        Promise<void>;

        Logout: () => void;
}

export interface IAuthProvider {
    children: JSX.Element
}