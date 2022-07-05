export const contains = (where, what) => {
    //Checking for the occurrence of one array in another
    what.map(a => {
        if (where.findIndex(b => b.id === a.id) < 0)
            return false
    })

    return true;
}