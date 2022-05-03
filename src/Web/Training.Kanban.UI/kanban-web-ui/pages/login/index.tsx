import { NextResponse } from "next/server";
import { useState } from "react";
import { useAuth } from "../../src/context/AuthProvider/useAuth";

const Login = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const auth = useAuth();

    async function onFinish(values: { username: string, password: string }) {
        const user = await auth.Authenticate(values.username, values.password);

        if (user)
            NextResponse.redirect("localhost:3000");
    }


    return (
        <div className="kb-login">
            <div className="kb-sign-body">
                <section className="kb-sign">
                    <div className="kb-sign-change-form">
                        <span>
                            <p>You don't have <br /> an account?</p>
                            <button className="kb-secundary-button">Sign-up</button>
                        </span>
                    </div>
                    <form className="kb-sign-form">
                        <div className="kb-sign-form-title">
                            <p>Access to Kanban</p>
                        </div>
                        <div className="kb-sign-form-inputs">
                            <label className="kb-sing-form-label">
                                <p>Username</p>
                                <input type="text" onChange={e => setUsername(e.target.value)} value={username} className="kb-sign-form-input-text" id="username"></input>
                            </label>
                            <label className="kb-sing-form-label">
                                <p>Password</p>
                                <input type="password" onChange={e => setPassword(e.target.value)} value={password} className="kb-sign-form-input-text" id="password"></input>
                                <label className="kb-sing-form-label-remember-pass">
                                    <p>Remember password?</p>
                                    <input type="checkbox" ></input>
                                </label>
                            </label>
                        </div>
                        <div className="kb-sign-form-footer">
                            <div>
                                <p>Forgot password?&nbsp;</p>
                                <a href="#">Recover here</a>
                            </div>
                            <input className="kb-primary-button" type="button" onClick={() => onFinish({ username: username, password: password })} value="Login"></input>
                        </div>
                    </form>
                </section>
            </div>
        </div>
    );
}

export default Login;
