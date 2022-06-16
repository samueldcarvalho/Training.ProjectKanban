import Link from "next/link";
import { useState } from "react";
import { useForm } from "react-hook-form";

type RegisterFormType = {
  onSubmit: (name: string, email: string, username: string, password: string) => void;
};

const RegisterForm = ({ onSubmit }: RegisterFormType) => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [passwordRepeat, setPasswordRepeat] = useState("");

  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
  } = useForm<{
    name: string;
    email: string;
    username: string;
    password: string;
    passwordRepeat: string;
  }>();

  const onSubmitValidate = handleSubmit(() => {
    onSubmit(name, email, username, password);
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
        <p>Create a new Account</p>
      </div>
      <div className="kb-sign-form-inputs">
        <label className="kb-sing-form-label">
          <p>Name</p>
          <input
            {...register("name", {
              required: { value: true, message: "Name is required" },
              minLength: { value: 3, message: "Minimum length is 3" },
              maxLength: { value: 100, message: "Max length is 100 " },
              pattern: {
                value: RegExp("^[a-zA-Z ]{6,100}$"),
                message: "Name must contain only letters. [a-Z]",
              },
            })}
            type="text"
            name="name"
            id="name"
            onChange={(e) => setName(e.target.value)}
            value={name}
            className="kb-sign-form-input-text"
            autoComplete="none"
          />
          {errors.name && <span className="formValidationSpan">{errors.name.message}</span>}
        </label>
        <label className="kb-sing-form-label">
          <p>E-mail</p>
          <input
            {...register("email", {
              required: { value: true, message: "Email is required" },
              pattern: {
                value: RegExp(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/),
                message: "Invalid email",
              },
            })}
            type="text"
            name="email"
            id="email"
            onChange={(e) => setEmail(e.target.value)}
            value={email}
            className="kb-sign-form-input-text"
            autoComplete="none"
          />
          {errors.email && <span className="formValidationSpan">{errors.email.message}</span>}
        </label>
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
          {errors.username && <span className="formValidationSpan">{errors.username.message}</span>}
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
          {errors.password && <span className="formValidationSpan">{errors.password.message}</span>}
        </label>
        <label className="kb-sing-form-label">
          <p>Repeat Password</p>
          <input
            {...register("passwordRepeat", {
              validate: (value) => value === password || "The passwords don't match",
              required: {
                value: true,
                message: "Repeat the password",
              },
            })}
            type="password"
            name="passwordRepeat"
            id="passwordRepeat"
            onChange={(e) => setPasswordRepeat(e.target.value)}
            value={passwordRepeat}
            className="kb-sign-form-input-text"
          />
          {errors.passwordRepeat && <span className="formValidationSpan">{errors.passwordRepeat.message}</span>}
        </label>
      </div>
      <div className="kb-sign-form-footer">
        <button className="kb-primary-button" type="submit">
          Register
        </button>
        <div id="KbSignFormFooterLoginRout">
          <p>Do you already have an account?&nbsp;</p>
          <Link href={"/login"}>
            <a href="#">Sign in!</a>
          </Link>
        </div>
      </div>
    </form>
  );
};

export default RegisterForm;
