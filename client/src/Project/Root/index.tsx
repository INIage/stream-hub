import Preact from 'preact/compat';
import { Provider } from 'react-redux';

import { App } from '../App';
import { store } from './Redux';

export const Root = () => {
  return (
    <Provider store={store}>
      <App />
    </Provider>
  );
};
