import { useState } from "react";
import { useForm } from "react-hook-form";
import { AiFillWarning } from "react-icons/ai";
import { MdWarning } from "react-icons/md";
import InvalidInputMessage from "../globals/Forms/InvalidInputMessage/InvalidInputMessage";

type LoginFormType = {
  onSubmit: (username: string, password: string) => void;
};

const LoginForm = ({ onSubmit }: LoginFormType) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<{ username: string; password: string }>();

  const onSubmitValidate = handleSubmit((data) => {
    onSubmit(username, password);
  });

  return (
    <form
      autoComplete="off"
      className="kb-sign-form"
      onSubmit={(event) => {
        event.preventDefault();
        onSubmitValidate();
      }}
    >
      <div className="kb-sign-form-title">
        <p>Login</p>
      </div>
      <div className="kb-sign-form-inputs">
        <label className="kb-sing-form-label">
          <p>Username</p>
          <input
            {...register("username", {
              required: { value: true, message: "Username is required" },
              minLength: { value: 3, message: "Minimum length is 3" },
              maxLength: { value: 26, message: "Maximum length is 26" },
              pattern: {
                value: RegExp("^[a-zA-Z0-9]{3,27}$"),
                message: "Invalid character",
              },
            })}
            type="text"
            name="username"
            id="username"
            onChange={(e) => setUsername(e.target.value)}
            value={username}
            className="kb-sign-form-input-text"
            autoComplete="none"
          />
          {errors.username && <InvalidInputMessage message={errors.username.message!} />}
        </label>
        <label className="kb-sing-form-label">
          <p>Password</p>
          <input
            {...register("password", {
              required: { value: true, message: "Password is required" },
              minLength: { value: 4, message: "Minimum length is 4" },
              maxLength: { value: 26, message: "Maximum length is 26" },
            })}
            type="password"
            name="password"
            id="password"
            onChange={(e) => setPassword(e.target.value)}
            value={password}
            className="kb-sign-form-input-text"
            autoComplete="none"
          />
          {errors.password && <InvalidInputMessage message={errors.password.message!} />}
          <label className="kb-sing-form-label-remember-pass">
            <p>Remember me?</p>
            <input type="checkbox"></input>
          </label>
        </label>
      </div>
      <div className="kb-sign-form-footer">
        <div id="KbSignFormFooterLoginRout">
          <p>Forgot password?&nbsp;</p>
          <a href="#">Recover here</a>
        </div>
        <button className="kb-primary-button" type="submit">
          Login
        </button>
      </div>
    </form>
  );
};

export default LoginForm;
