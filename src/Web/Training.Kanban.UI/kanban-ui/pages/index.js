export default () => {
    return (
        <div className="kb-login">
            <header className="container kb-top-main-menu">
                <div className="col-6 kb-top-main-menu-logo">
                    Kanban
                </div>
            </header>
            <div className="kb-sign-body">
                <section className="kb-sign">
                    <div className="kb-sign-change-form">
                        <span>
                            <p>You don't have <br /> an account?</p>
                            <button className="kb-secundary-button">Sing-up</button>
                        </span>
                    </div>
                    <form className="kb-sign-form">
                        <div className="kb-sign-form-title">
                            <p>Sign-in</p>
                        </div>
                        <div className="kb-sign-form-inputs">
                            <label className="kb-sing-form-label" for="username">
                                <p>Username</p>
                                <input type="text" className="kb-sign-form-input-text" id="username"></input>
                            </label>
                            <label className="kb-sing-form-label" for="password">
                                <p>Password</p>
                                <input type="password" className="kb-sign-form-input-text" id="password"></input>
                                <label className="kb-sing-form-label-remember-pass">
                                    <p>Remember password?</p>
                                    <input type="checkbox" ></input>
                                </label>
                            </label>
                        </div>
                        <div className="kb-sign-form-footer">
                            <div>
                                <p>Esqueceu a senha?&nbsp;</p>
                                <a href="#">Resgatar</a>
                            </div>
                            <input className="kb-primary-button" type="submit" value="Login"></input>
                        </div>
                    </form>
                </section>
            </div>
        </div>
    );
}
