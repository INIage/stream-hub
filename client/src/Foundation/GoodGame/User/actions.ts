import { User } from 'Features/Main/models';

import * as constant from './constants';
import { Action } from './models';

export const SetUser = (user: User): Action<User> => ({
  payload: user,
  type: constant.SET_USER,
});
