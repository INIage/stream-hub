import * as constant from './constants';
import { Action, UserState } from './models';

const initial: UserState = JSON.parse(window.localStorage.getItem('GoodGameUser'));

export const UserReducer = (state: UserState = initial, action: Action<any>) => {
  switch (action.type) {
    case constant.SET_USER:
      window.localStorage.setItem('GoodGameUser', JSON.stringify(action.payload));
      return {
        ...action.payload,
      };
    default:
      return state;
  }
};
