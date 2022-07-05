import React from 'react';
import cl from './PageNavigation.module.css';

const PageNavigation = ({ totalPages, isLoading, page, changePage  }) => {

    return (
        <div>
            {(totalPages > 1 && !isLoading) &&
                <div className={cl.pageSwitch}>
                    {page > 1 &&
                        <span className={cl.switchingPrev} onClick={() => changePage(page - 1)}><strong>Previous page</strong></span>
                    }
                    <span className={cl.textNav}><strong>{page} / {totalPages}</strong></span>
                    {page < totalPages &&
                        <span className={cl.switchingNext} onClick={() => changePage(page + 1)}><strong>Next page</strong></span>
                    }
                </div>
            }
        </div>
    );
};

export default PageNavigation;