export interface IUser {
    email?: string,
    username?: string,
    name?: string,
    token?: string,
}

export interface IContext extends IUser {
    Authenticate: (username: string, password: string) =>
        Promise<IUser | null>;

    Logout: () => void;
}

export interface IAuthProvider {
    children: JSX.Element
}
