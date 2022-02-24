export default function Singin() {
    return (
        <div className="kb-login-form-signup">
            <p className="kb-form-title">
                Login
            </p>
            <div className="kb-login-entries">
                <label for="kb-login-username">
                    <p>Username</p>
                    <input type="text" className="kb-input-text-sign" id="kb-login-username" />
                </label>
                <label for="kb-login-password">
                    <p>Password</p>
                    <input type="password" className="kb-input-text-sign" id="kb-login-password" />
                </label>
            </div>
            <div className="kb-remember-password">
                <p>Lembrar a senha?</p>
                <input type="checkbox" id="kb-input-checkbox-main" />
            </div>
            <div>
                <span>
                    <p className="kb-text-main">Esqueceu a senha? </p>
                    <p className="kb-link-main">Resgatar </p>
                </span>
                <input type="button" value="submit" className="kb-button-main-filled" />
            </div>
        </div>
    )
}
