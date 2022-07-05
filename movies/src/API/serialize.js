import { default as qs } from "qs";

export const objectToQueryString = (obj, options = {}) => {
    return qs.stringify(obj, { ...options, skipNulls: true });
};
