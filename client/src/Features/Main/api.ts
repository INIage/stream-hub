import axios from 'axios';

import { LoginResponce } from './models';

export const login = (username: string, password: string) => {
  const payload = {
    password,
    username,
  };

  return axios
    .post<LoginResponce>('https://goodgame.ru/api/4/login/password', payload)
    .then(responce => responce.data);
};
