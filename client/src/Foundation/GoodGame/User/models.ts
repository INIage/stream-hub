import { User } from 'Features/Main/models';

export interface UserState {
  user: User;
}

export interface Action<T> {
  payload: T;
  type: string;
}
