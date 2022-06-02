const AccessTokenKey = "ACCESS_TOKEN";

const Save = (jwt: string) => {
  globalThis?.sessionStorage.setItem(AccessTokenKey, jwt);
};

const Get = () => {
  return globalThis?.sessionStorage.getItem(AccessTokenKey);
};

const Remove = () => {
  globalThis?.sessionStorage.removeItem(AccessTokenKey);
};

export const TokenService = {
  Save,
  Get,
  Remove,
};
