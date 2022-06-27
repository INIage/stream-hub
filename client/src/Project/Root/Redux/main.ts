import { Action } from 'redux';

interface State {
  count: number;
}

const INCREMENT = 'INCREMENT';
const DECREMENT = 'DECREMENT';

const increment = (amount: number): Action<typeof INCREMENT> & { amount: number } => ({
  type: INCREMENT,
  amount,
});

const decrement = (amount: number): Action<typeof DECREMENT> => ({
  type: DECREMENT,
});

type Actions = ReturnType<typeof increment> | ReturnType<typeof decrement>;

const reducer = (state: State, action: Actions): State => {
  action.type = getType('', action.type);

  switch (Action.type) {
    case INCREMENT:
      return {
        count: state.count + Action.amount,
      };
    case DECREMENT:
      return {
        count: state.count - 1,
      };
    default:
      return state;
  }
};

const getType = <T>(prename: string, type: T): T => `${prename}_${type}`;
