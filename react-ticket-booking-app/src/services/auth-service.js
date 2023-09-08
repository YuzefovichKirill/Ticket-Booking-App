import { UserManager } from 'oidc-client'
import environment from '../environments/environment'
import { Subject } from 'rxjs';
import jwt_decode from 'jwt-decode'

const settings = {
    authority: environment.AuthorityUrl,
    client_id: environment.clientId,
    redirect_uri: environment.clientUrl + '/signin-callback',
    scope: 'openid profile roles TicketBookingAPI',
    response_type: 'id_token token',
    post_logout_redirect_uri: environment.clientUrl + '/signout-callback'
}

const userManager = new UserManager(settings);
var user = null;
const loginChangedSubject = new Subject();
export var loginChanged = loginChangedSubject.asObservable();

export function login() {
    return userManager.signinRedirect();
}

export function finishLogin() {
    return userManager.signinRedirectCallback()
        .then(_user => {
            user = _user;
            loginChangedSubject.next(checkUser(user));
            return user;
        })
}

export function logout() {
    return userManager.signoutRedirect();
}

export function finishLogout() {
    user = null;
    return userManager.signoutRedirectCallback();
}

export function checkUser(_user) {
    return !!_user && !_user.expired;
}

export function getAccessToken() {
    return userManager.getUser()
        .then(_user => {
            return !!_user && !_user.expired ? _user.access_token : null;
        })
}

export function getRole(user) {
    var token = user?.access_token
    if (!token) return null
    const decodedToken = jwt_decode(token)
    const role = decodedToken.role
    return role
}

export default userManager