import { Injectable, OnDestroy } from '@angular/core';
import { Subject, BehaviorSubject, fromEvent } from 'rxjs';
import { takeUntil, debounceTime } from 'rxjs/operators';
import { Router } from '@angular/router';
import { LocalStorageConstants } from '@constants/local-storage.constants';
import { MenuWithRole } from '@models/menu';

// Menu
export interface Menu {
	headTitle1?: string,
	headTitle2?: string,
	path?: string;
	title?: string;
	icon?: string;
	type?: string;
	badgeType?: string;
	badgeValue?: string;
	active?: boolean;
	bookmark?: boolean;
	children?: Menu[];
}

@Injectable({
	providedIn: 'root'
})

export class NavService implements OnDestroy {

	private unsubscriber: Subject<any> = new Subject();
	public screenWidth: BehaviorSubject<number> = new BehaviorSubject(window.innerWidth);

	// Language
	public language: boolean = false;

	// For Horizontal Layout Mobile
	public horizontal: boolean = window.innerWidth < 991 ? false : true;

	// Collapse Sidebar
	public collapseSidebar: boolean = window.innerWidth < 991 ? true : false;

	// Full screen
	public fullScreen: boolean = false;

	public menus: MenuWithRole[] = JSON.parse(localStorage.getItem(LocalStorageConstants.MENUS));

	public MENUITEMS: Menu[] = [];

	constructor(private router: Router) {
		this.setScreenWidth(window.innerWidth);
		fromEvent(window, 'resize').pipe(
			debounceTime(1000),
			takeUntil(this.unsubscriber)
		).subscribe((evt: any) => {
			this.setScreenWidth(evt.target.innerWidth);
			if (evt.target.innerWidth < 991) {
				this.collapseSidebar = true;
			}
		});
		if (window.innerWidth < 991) { // Detect Route change sidebar close
			this.router.events.subscribe(event => {
				this.collapseSidebar = true;
			});
		}
		this.getMenus();
	}

	getMenus() {
		if (this.menus)
			this.menus[0].active = true;

		this.menus.filter(x => x.parent_Id === null)?.map(item => {
			let children = this.menus.filter(x => x.parent_Id === item.id).map(child => {
				let menuChild: Menu = { ...child };
				return menuChild;
			});

			let menu: Menu = { ...item };

			if (children?.length > 0) {
				children[0].active = true;
				menu.children = [...children];
			}

			this.MENUITEMS.push(menu);
		});
	}

	ngOnDestroy() {
		this.unsubscriber.next();
		this.unsubscriber.complete();
	}

	private setScreenWidth(width: number): void {
		this.screenWidth.next(width);
	}

	// Array
	items = new BehaviorSubject<Menu[]>(this.MENUITEMS);
}
